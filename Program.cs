using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsumindoApiRest
{
    class Program
    {
        static void Main(string[] args)
        {
            string urlGet = "https://jsonplaceholder.typicode.com/posts/1";
            //Cria requisição passando URL
            WebRequest requestGet = WebRequest.Create(urlGet);
            //Informa o metodo
            requestGet.Method = "GET";
            //cria objeto que recebera a resposta
            HttpWebResponse responseGet = (HttpWebResponse)requestGet.GetResponse();
            //vai ler a resposta
            string strResult = "";
            using(Stream stream = responseGet.GetResponseStream()){
                //cria um StreamReader para receber o scream
                StreamReader sr = new StreamReader(stream);
                //armazena todo o conteudo na string
                strResult = sr.ReadToEnd();
                //fecha StreamReader
                sr.Close();
            }
            Console.WriteLine("GET: \n" + strResult);

            //POST
            string urlPost = "https://jsonplaceholder.typicode.com/posts";
            WebRequest requestPost = WebRequest.Create(urlPost);
            requestPost.Method = "POST";
            requestPost.ContentType = "application/json";
            string jsonPost = "{\"title\":\"testTitleData\",\"body\":\"testBodyData\",\"userId\":\"50\"}";
            //usa StreamWriter para escrever o obj
            //passa como paramentro a requisicao
            using(StreamWriter sw = new StreamWriter(requestPost.GetRequestStream())){
                //passa json como parametro de escrita
                sw.Write(jsonPost);
                //Flush e Close
                sw.Flush();
                sw.Close();

                //armazena resposta no response
                HttpWebResponse responsePost = (HttpWebResponse)requestPost.GetResponse();
                
                //utilizando o responsePost para obter a resposta da requisição
                using(StreamReader sr = new StreamReader(responsePost.GetResponseStream())){
                    //recebe resposta
                    strResult = sr.ReadToEnd();
                }
            }

            Console.WriteLine("POST: \n" + strResult);

        }
    }
}
