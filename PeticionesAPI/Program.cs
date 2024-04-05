using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text;
using Newtonsoft.Json;

//Utilizar Newtownsoft.Json.linq & System.Net.Http



using (var client = new HttpClient())
{
    //METODO GET --------

    string url = "https://jsonplaceholder.typicode.com/posts/1";

    client.DefaultRequestHeaders.Clear(); //Esto limpia la petición por completo de cualquier tipo de encabezado.

    //client.DefaultRequestHeaders.Add("Authorization", "TOKEN"); //Esto se utiliza en el caso de que la API nos pida un token de seguridad o algún parametro de autorización 

    var response = client.GetAsync(url).Result; //El resultado de el GetAsync lo guarda en la variable response.

    var res = response.Content.ReadAsStringAsync().Result; //ReadAsStringAsync extrae el contenido y lee response y lo guardamos en res.

    dynamic r = JObject.Parse(res); //Parseamos la respuesta a objeto dinámico y ya está lista la respuesta.

    Console.WriteLine(r);

    //METODO GET ---------


    //METODO POST --------

    string url2 = "https://jsonplaceholder.typicode.com/posts";

    client.DefaultRequestHeaders.Clear();
    string parametros = "{'title': 'Aprendiendo API con .NET realizando un POST', 'body': 'Esto es una prueba de post', 'userId': '13'}"; //Definimos los parametros a agregar.
    dynamic jsonString = JObject.Parse(parametros); //Los agregamos como objeto dinamico parseandolos

    var HttpContent = new StringContent(jsonString.ToString(), Encoding.UTF8, "application/json"); //Realizamos el nuevo conenido del string y el encoding para que la API lo reciba.
    var response2 = client.PostAsync(url2, HttpContent).Result; // creamos la respuesta de post
    var res2 = response2.Content.ReadAsStringAsync().Result; //Que lo lea como string y creamos la variable res
    dynamic r2 = JObject.Parse(res2); // parseamos el objeto a dinámico y ya está listo para pasarlo a lectura por consola

    Console.WriteLine(r2);

    //METODO POST --------

    //METODO PUT --------
    //El metodo Put es muy parecido al método Post.
    string url3 = "https://jsonplaceholder.typicode.com/posts/1";

    client.DefaultRequestHeaders.Clear();
    string parametros3 = "{'title': 'Aprendiendo API con .NET haciendo un PUT', 'body': 'Esto es una prueba de put', 'userId': '13'}";
    dynamic jsonString3 = JObject.Parse(parametros3);

    var HttpContent3 = new StringContent(jsonString3.ToString(), Encoding.UTF8, "application/json");
    var response3 = client.PutAsync(url3, HttpContent3).Result; //Lo único que cambia es que en vez de realizar un PostAsync es PutAsync
    var res3 = response3.Content.ReadAsStringAsync().Result;
    dynamic r3 = JObject.Parse(res3);

    Console.WriteLine(r3);

    //METODO PUT --------

    //METODO PATCH --------
    //El metodo Patch es muy parecido al método Post igualmente.
    string url4 = "https://jsonplaceholder.typicode.com/posts/1";

    client.DefaultRequestHeaders.Clear();
    string parametros4 = "{'title': 'Aprendiendo API con .NET haciendo un PATCH'}";
    dynamic jsonString4 = JObject.Parse(parametros4);

    var HttpContent4 = new StringContent(jsonString4.ToString(), Encoding.UTF8, "application/json");
    var response4 = client.PatchAsync(url4, HttpContent4).Result; //Lo mismo que antes, solamente cambiamos PutAsync por PatchAsync
    var res4 = response4.Content.ReadAsStringAsync().Result;
    dynamic r4 = JObject.Parse(res4);

    Console.WriteLine(r4);

    //METODO PATCH --------

    //METODO GET ALL --------

    string url5 = "https://jsonplaceholder.typicode.com/posts";

    client.DefaultRequestHeaders.Clear(); //Esto limpia la petición por completo de cualquier tipo de encabezado.

    //client.DefaultRequestHeaders.Add("Authorization", "TOKEN"); //Esto se utiliza en el caso de que la API nos pida un token de seguridad o algún parametro de autorización 

    var response5 = client.GetAsync(url5).Result; //El resultado de el GetAsync lo guarda en la variable response.

    var res5 = response5.Content.ReadAsStringAsync().Result; //ReadAsStringAsync extrae el contenido y lee response y lo guardamos en res.

    // Deserializa la respuesta en una lista de objetos (asumiendo que la respuesta es una matriz de objetos JSON)
    JArray posts = JArray.Parse(res5);

    Console.WriteLine($"------------------");
    Console.WriteLine("ALL POSTS");
    Console.WriteLine($"------------------");
    foreach ( var post in posts) { 
        Console.WriteLine($"{post}");
    }

    //METODO GET ALL---------

    Console.ReadLine();
    //Importante!! : el servidor que estamos utilizando es falso así que la información que se esta "editando" no cambia realmente, estos cambios pueden que no se reflejen cuando se muestren en consola.

}