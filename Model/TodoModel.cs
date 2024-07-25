public class Todo{
    // (int id,string task,bool status)
    public int Id{get;set;}
    public string Task{get;set;}
    public bool Status{get;set;}

};
record HttpResponse(string message,int status);
