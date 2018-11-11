import java.util.HashMap;
import java.util.Map;
import java.util.Vector;
public class Teacher extends Person {
    private String id,login,password;
    Vector<Student> students;
    /*public enum position{
        Tutor,
        Lector,
        Senior_lector,
        Professor;
    }
    */
    private Vector<String> subjects;
    public Teacher(){
        students=new Vector<>();
        subjects=new Vector<>();
        id="no id";
        login="no login";
        password="no password";

    }
    public Teacher(String surname,String name,int age ,String login,String id,String password ){
        super(surname, name, age);
        this.id=id;
        this.login=login;
        this.password=password;
        this.subjects=new Vector<>();
        students=new Vector<>();
    }
    public String getName(){
        return super.getName();
    }
    public String getSurname(){
        return super.getSurname();
    }
    public String getId(){
        return id;
    }
    public String getLogin(){
        return login;
    }
    public String getPassword(){
        return password;
    }
    public void setId(String id){
        this.id=id;
    }
    public void setLogin(String login){
        this.login=login;
    }
    public void setPassword(String password){
        this.password=password;
    }



    public void addSubject(String subject){
        this.subjects.add(subject);
    }
    public String getSubjects(){
        String s="";
        for (int i=0;i<subjects.size();++i)
            s=s+"\n"+"Subject-"+(i+1)+":"+subjects.elementAt(i);
        return s;

    }
    public void removeSubject(String subject){
        for (int i=0;i<subjects.size();++i)
            if (subjects.elementAt(i)==subject){
                subjects.removeElementAt(i);
                return;
            }
    }

    @Override
    public boolean equals(Object obj) {
        return (super.equals(obj) && this.getId()==((Student)obj).getId()) ;
    }

    @Override
    public String toString() {
        return super.toString();
    }
}