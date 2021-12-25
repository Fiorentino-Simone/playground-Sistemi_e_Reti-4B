using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;//import per gli XML
using System.Threading;
using System.Diagnostics;

namespace Edit_XML
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCreaXML_Click(object sender, EventArgs e)
        {
            XmlTextWriter xmlWrt;
            string pathXml = "fatturaTest.xml"; //anche tramite la browse file dialog come con il notepad
            xmlWrt = new XmlTextWriter(pathXml, Encoding.UTF8);

            xmlWrt.Formatting = Formatting.Indented; //settiamo la formattazione indentata

            /*INTESTAZIONE*/
            //costruisco un nodo da 0 tramite la procedura WriteStartElement
            xmlWrt.WriteStartElement("p:FatturaElettronica"); //passiamo una stringa con il nome del nodo

            /*ATTRIBUTI*/
            //bisogna settare gli attributi obbligatori (ricordo cambia la versione come attributo il restante sono standard)
            xmlWrt.WriteAttributeString("xmlns:ds", "http://www.w3.org/2000/09/xmldsig#");
            xmlWrt.WriteAttributeString("xmlns:p", "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2");
            xmlWrt.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xmlWrt.WriteAttributeString("versione", "FPA12");
            xmlWrt.WriteAttributeString("xsi:schemaLocation", "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2 http://www.fatturapa.gov.it/export/fatturazione/sdi/fatturapa/v1.2/Schema_del_file_xml_FatturaPA_versione_1.2.xsd");

            /*HEADER*/
            xmlWrt.WriteStartElement("FatturaElettronicaHeader");
            xmlWrt.WriteStartElement("DatiTrasmissione");
            xmlWrt.WriteStartElement("IdTrasmittente");

            //IdTrasmittente
            xmlWrt.WriteElementString("IdPaese", "IT");
            xmlWrt.WriteElementString("IdCodice", "01234567890");

            xmlWrt.WriteEndElement(); //IdTrasmittente
            xmlWrt.WriteEndElement(); //DatiTrasmissione
            xmlWrt.WriteEndElement(); //adesso chiuderà non p:FatturaElettronica ma quello Header
            xmlWrt.WriteEndElement(); //chiude l'ultimo nodo creato
            xmlWrt.Close();
            Process.Start("explorer.exe", "/select," + pathXml);
        
            /*TIPS: 
             * 
             * utilizzare classi apposite per migliorare la creazione dinamica del xml
             * Uso dei thread per i controlli
             * */
        }
    }
}
