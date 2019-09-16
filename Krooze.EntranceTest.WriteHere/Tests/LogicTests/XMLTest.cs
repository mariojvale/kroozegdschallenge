using Krooze.EntranceTest.WriteHere.Structure.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Krooze.EntranceTest.WriteHere.Tests.LogicTests
{
    public class XMLTest
    {
        public CruiseDTO TranslateXML()
        {
            //TODO: Take the Cruises.xml file, on the Resources folder, and translate it to the CruisesDTO object,
            //you can do it in any way, including intermediary objects
                        
            XmlDocument oXML = new XmlDocument();
            CruiseDTO cruise = new CruiseDTO();
            PassengerCruiseDTO passengerCruise = new PassengerCruiseDTO();
            List<PassengerCruiseDTO> PassengerCruise = new List<PassengerCruiseDTO>();
            

            //Define o caminho do arquivo XML 
            string ArquivoXML = "C:\\Users\\alvaro.gouveia\\Desktop\\kroozegdschallenge-master\\Krooze.EntranceTest.WriteHere\\Resources\\Cruises.xml";
            //carrega o arquivo XML
            oXML.Load(ArquivoXML);

            XDocument xmlDoc = XDocument.Load(ArquivoXML);
             
            foreach (var cliente in xmlDoc.Descendants("Cruises"))
            {
                cruise.CruiseCode = cliente.Element("CruiseId").Value;
                cruise.ShipName = cliente.Element("ShipName").Value;
                cruise.TotalValue = decimal.Parse(cliente.Element("TotalCabinPrice").Value.ToString().TrimEnd('0'));
                cruise.PortCharge = decimal.Parse(cliente.Element("PortChargesAmt").Value.ToString().TrimEnd('0'));
                cruise.CabinValue = decimal.Parse((cliente.Element("CabinPrice").Value).ToString().TrimEnd('0'));               
                
            }

            
            foreach (var cliente in xmlDoc.Descendants("Pax"))
            {
                passengerCruise = new PassengerCruiseDTO();
                passengerCruise.Cruise = new CruiseDTO();
                
                passengerCruise.PassengerCode = cliente.FirstAttribute.Value; //oXML.SelectSingleNode("Cruises/CategoryPriceDetails/Pax").Attributes.GetNamedItem("PaxID").Value;
                passengerCruise.Cruise.CabinValue = decimal.Parse(oXML.SelectSingleNode("Cruises").ChildNodes[21].ChildNodes[0].ChildNodes[10].ChildNodes[5].InnerText.Trim('0'));
                passengerCruise.Cruise.PortCharge = decimal.Parse(oXML.SelectSingleNode("Cruises").ChildNodes[21].ChildNodes[0].ChildNodes[11].ChildNodes[5].InnerText.Trim('0'));
                passengerCruise.Cruise.TotalValue = decimal.Parse(oXML.SelectSingleNode("Cruises").ChildNodes[21].ChildNodes[0].ChildNodes[8].InnerText.Trim('0'));
                passengerCruise.Cruise.CruiseCode = cruise.CruiseCode;
                passengerCruise.Cruise.ShipName = cruise.ShipName;

                PassengerCruise.Add(passengerCruise);
            }

            cruise.PassengerCruise = PassengerCruise;
          
            return cruise ;
        

            

            
        }
    }
}
