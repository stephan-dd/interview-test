using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Xml;
using InterviewTest.Controllers;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.EntityFrameworkCore;

namespace InterviewTest
{
    public class Helper
    {
        public static Hero[] GetHeroesFromXml()
        {
            //Load the xml data file
            XmlDocument xmlDocObj = new XmlDocument();
            string filePath = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            xmlDocObj.Load($@"{filePath}\\InterviewTest\\Data\\HeroesData.xml");
            
            //Get List of heroes in xml node format
            XmlNodeList heroesXml = xmlDocObj.SelectNodes("//hero");
            int len = heroesXml.Count;
            Hero[] heroes = new Hero[len];

            //append the heroes array with the values from the xml nodes
            for (int i = 0; i < heroesXml.Count; i++)
            {
                if (heroesXml[i].InnerText.Length > 0)
                {
                    heroes[i] = new Hero
                    {
                        Id = int.Parse(heroesXml[i].FirstChild.InnerText),
                        Name = heroesXml[i].SelectSingleNode("Name").InnerText,
                        Power = heroesXml[i].SelectSingleNode("Power").InnerText,
                        Stats = new List<KeyValuePair<string, double>>()
                        {
                            new KeyValuePair<string, double>("strength",
                                double.Parse(heroesXml[i].SelectSingleNode("Stats/strength").InnerText)),
                            new KeyValuePair<string, double>("intelligence",
                                double.Parse(heroesXml[i].SelectSingleNode("Stats/intelligence").InnerText)),
                            new KeyValuePair<string, double>("stamina",
                                double.Parse(heroesXml[i].SelectSingleNode("Stats/stamina").InnerText))
                        },
                        LastUpdated = Boolean.Parse(heroesXml[i].SelectSingleNode("LastUpdated").InnerText)
                    };
                }
            }

            xmlDocObj.Save($@"{filePath}\\InterviewTest\\Data\\HeroesData.xml");
            return heroes;
        }

        public static void UpdateHeroStats(Hero hero)
        {
            XmlDocument xmlDocObj = new XmlDocument();
            string filePath = Path.GetDirectoryName(Directory.GetCurrentDirectory());
            xmlDocObj.Load($@"{filePath}\\InterviewTest\\Data\\HeroesData.xml");

            //XmlNode heroNode = xmlDocObj.SelectSingleNode($"/heroes/hero[Id={hero.Id}]");
            XmlNode statsNode = xmlDocObj.SelectSingleNode($"/heroes/hero[Id={hero.Id}]/Stats");

            statsNode.ChildNodes[0].InnerText = hero.Stats[0].Value.ToString();
            statsNode.ChildNodes[1].InnerText = hero.Stats[1].Value.ToString();
            statsNode.ChildNodes[2].InnerText = hero.Stats[2].Value.ToString();

            XmlNodeList lastUpdatedList = xmlDocObj.SelectNodes($"/heroes/hero/LastUpdated");
            for (int i = 0; i < lastUpdatedList.Count; i++)
            {
                lastUpdatedList[i].InnerText = "False";
            }

            XmlNode lastUpdatedNode = xmlDocObj.SelectSingleNode($"/heroes/hero[Id={hero.Id}]/LastUpdated");
            lastUpdatedNode.InnerText = hero.LastUpdated.ToString();
            xmlDocObj.Save($@"{filePath}\\InterviewTest\\Data\\HeroesData.xml");
        }
    }
}
