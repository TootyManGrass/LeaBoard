using UnityEngine;
//using Newtonsoft.Json;

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
        //add a copy of TCPConnection to this game object
        myTCP = gameObject.AddComponent<TCPConnection>();
    }

    void Start()
    {
		txtcntrl = screentxt.GetComponent<TextController> ();
    }

    void Update()
    {
        //keep checking the server for messages, if a message is received from server, it gets logged in the Debug console (see function below)
        SocketResponse();
    }

    void OnGUI()
    {
        //if connection has not been made, display button to connect
        if (myTCP.socketReady == false)
        {
            if (GUILayout.Button("Connect"))
            {
                //try to connect
                Debug.Log("Attempting to connect..");
                myTCP.setupSocket();
				SendToServer (getJson ("k3273159@mvrht.com", "promisetest"));
            }
        }

        //once connection has been made, display editable text field with a button to send that string to the server (see function below)
        if (myTCP.socketReady == true)
        {
            username = GUILayout.TextField(username);
            message = GUILayout.TextField(message);
            if (GUILayout.Button("Write to server", GUILayout.Height(30)))
            {
                //SendToServer(message);
                SendToServer(getJson(username, message));
            }
        }

    }

    //socket reading script
    void SocketResponse()
    {
        string serverSays = myTCP.readSocket();
        if (serverSays != "")
        {
            Debug.Log("[SERVER]" + serverSays);

            string parsed = parseJson(serverSays);
            //if (parsed != null)
            //{
                Debug.Log("Parsed: " + parsed);
				txtcntrl.updateScreen_them (parsed);
            //}
        }
    }

    //send message to the server
    public void SendToServer(string str)
    {
        myTCP.writeSocket(str);
        Debug.Log("[CLIENT] -> " + str);
        //Debug.Log("After parsing: " + parseJson(str));
    }

    public string getJson(string username, string message)
    {
        return "{\"user\": \"" + username + "\",\n\"text\": \"" + message + "\"}";
    }

    private string parseJson(string json)
    {
        FromServer obj = JsonUtility.FromJson<FromServer>(json);


            return "[" + obj.user + "]: " + obj.text;
        

        
    }
}
