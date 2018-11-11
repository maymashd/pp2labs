import java.util.Vector;
import java.util.*;
import java.util.Arrays;

import java.util.HashMap;
import java.util.HashSet;

public class Student extends Person {
    private String id;
    private boolean passed;
    private int yearOfStudy;
    private HashMap<Course, Double> marks;
    private double GPA;
    private Faculty faculty;
    private Vector<Course> current = new Vector<>();
    private Vector<Course> passed = new Vector<>();


    public Student(){

        id="no id";
        super.setLogin("no login");
        super.setPassword("no password");
        marks=new HashMap<>();

    }

    public void setMark(Course course, Double mark){
        if (hasSubject(course)){
            marks.put(course,Math.min(100,marks.));
        }
    }
    public boolean hasSubject(Course course){
        for (int i=0;i<current.size();++i){

                if (course.equals(current.elementAt(i) )){
                    return true;
                }

        }
        return false;
    }
    public double getMark(String subject){
        return marks.get(subject);

    }
    public Student(String surname,String name,int age ,String login,String id,String password,int course ){
        super(surname, name, age);
        this.id=id;
        this.course=course;
        this.login=login;
        this.password=password;
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
    public int getCourse(){
        return course;
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
    public void setCourse(int course){
        this.course=course;
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
}
