using UnityEngine;
using System.Collections;

public class TinyXmlReader
{
    private string xmlString = "";
    private int idx = 0;

    public TinyXmlReader(string newXmlString)
    {
        xmlString = newXmlString;
    }

    public string tagName = "";
    public bool isOpeningTag = false;
    public string content = "";

    public bool Read()
    {
        idx = xmlString.IndexOf("<", idx);
        if (idx == -1)
        {
            return false;
        }
        ++idx;

        int endOfTag = xmlString.IndexOf(">", idx);
        if (endOfTag == -1)
        {
            return false;
        }

        tagName = xmlString.Substring(idx, endOfTag-idx);

        idx = endOfTag;

        // check if a closing tag
        if (tagName.StartsWith("/"))
        {
            isOpeningTag = false;
            tagName = tagName.Remove(0, 1); // remove the slash
        }
        else
        {
            isOpeningTag = true;
        }

        // if an opening tag, get the content
        if (isOpeningTag)
        {
            int startOfCloseTag = xmlString.IndexOf("<", idx);
            if (startOfCloseTag == -1)
            {
                return false;
            }

            content = xmlString.Substring(idx+1, startOfCloseTag-idx-1);
            content = content.Trim();
        }

        return true;
    }

    // returns false when the endingTag is encountered
    public bool Read(string endingTag)
    {
        bool retVal = Read();
        if (tagName == endingTag && !isOpeningTag)
        {
            retVal = false;
        }
        return retVal;
    }
}

