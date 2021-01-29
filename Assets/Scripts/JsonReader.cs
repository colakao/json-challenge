using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

public class JsonReader : MonoBehaviour
{
    private string _jsonDirectory = Application.streamingAssetsPath.ToString() + "/JsonChallenge.json";
    private string _json;

    public string title;
    public List<string> headers;
    public List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();


    public void ReadFile()
    {
        _json = File.ReadAllText(_jsonDirectory);
        JObject _jsonObject = JObject.Parse(_json);

        //Asigna el titulo a title
        title = _jsonObject["Title"].ToString();

        //Asigna los headers a la lista
        headers = _jsonObject["ColumnHeaders"].Select(t => (string)t).ToList();

        //Asigna un Dictionary al key/value pair del json y lo mete a la lista

        for (int i = 0; i < _jsonObject["Data"].Children().Count(); i++)
        {
            string json = _jsonObject["Data"][i].ToString();
            data.Add(JsonConvert.DeserializeObject<Dictionary<string, string>>(json));
        }
    }

    //Limpia las variables que cambian
    public void ClearValues()
    {
        title = "";
        headers.Clear();
        data.Clear();
    }
}


