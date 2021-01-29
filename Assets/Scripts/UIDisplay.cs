using UnityEngine;
using UnityEngine.UI;

//Es común en mi código el spanglish
public class UIDisplay : MonoBehaviour
{
    public GameObject rowObject;
    public Text textObject;
    public Transform rowsTransform;
    public JsonReader json;

    public void ReloadUI()
    {
        if (json.data != null || json.headers != null || json.title != "")
        json.ClearValues();

        //Load/Reload File
        json.ReadFile();
        if (rowsTransform.childCount > 0)
        {
            foreach (Transform child in rowsTransform)
            {
                //No es muy eficiente pero cumple su función
                GameObject.Destroy(child.gameObject);
            }
        }

        //Load title
        GameObject firstRow = Instantiate(rowObject, rowsTransform);
        Text title = Instantiate(textObject, firstRow.transform);

        title.text = json.title.ToString();
        title.fontStyle = FontStyle.Bold;

        //Load rowObject and headers as text
        GameObject secondRow = Instantiate(rowObject, rowsTransform);
        for (int i = 0; i < json.headers.Count; i++)
        {
            Text localText = Instantiate(textObject, secondRow.transform);

            localText.text = json.headers[i].ToString();
            localText.fontStyle = FontStyle.Bold;
        }

        //Load more rowObjects and data as text
        for (int i = 0; i < json.data.Count; i++)
        {
            GameObject dataRow = Instantiate(rowObject, rowsTransform);
            foreach (var value in json.data[i].Values)
            {
                Text localText = Instantiate(textObject, dataRow.transform);

                localText.text = value.ToString();
            }
        }
    }
}
