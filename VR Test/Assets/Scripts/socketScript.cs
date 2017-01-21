using UnityEngine;

public class socketScript : MonoBehaviour
{
    //variables
    private TCPConnection myTCP;

    public string username;
    public string message;

	public GameObject screentxt;
	private TextController txtcntrl;

    void Awake()
    {
        myTCP = gameObject.AddComponent<TCPConnection>();
    }

    void Start()
    {
		txtcntrl = screentxt.GetComponent<TextController> ();

		myTCP.setupSocket();
		SendToServer (getJson ("k3273159@mvrht.com", "promisetest"));
    }

    void Update()
    {
        SocketResponse();
    }
		
    void SocketResponse()
    {
        string serverSays = myTCP.readSocket();
        if (serverSays != "")
        {
            Debug.Log("[SERVER]" + serverSays);

            string parsed = parseJson(serverSays);
            Debug.Log("Parsed: " + parsed);
			txtcntrl.updateScreen_them (parsed);
        }
    }

    //send message to the server
    public void SendToServer(string str)
    {
        myTCP.writeSocket(str);
        Debug.Log("[CLIENT] -> " + str);
    }

    public string getJson(string username, string message)
    {
        return "{\"user\": \"" + username + "\",\n\"text\": \"" + message + "\"}";
    }

    private string parseJson(string json)
    {
        FromServer obj = JsonUtility.FromJson<FromServer>(json);
           
		return "From [" + obj.user + "]: " + obj.text;
    }
}
