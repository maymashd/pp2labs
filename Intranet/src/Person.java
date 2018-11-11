import com.sun.org.apache.xpath.internal.operations.Equals;

import java.io.Serializable;

import java.lang.*;

import java.util.Scanner;

public class Person implements Serializable {
    private String name,surname,login,password;

    public Person(String surname,String name){
        this.name=name;
        this.surname=surname;
    }
    public Person(String login, String password, String name, String surname) {

        super();

        this.login = login;

        this.password = password;

        this.name = name;

        this.surname=surname;
    }

    public Person(String surname,String name,int age){
        this.name=name;
        this.surname=surname;

    }



    public Person(){
        name="no name";
        surname="no surname";

    }
    public void setName(String name){
        this.name=name;
    }
    public void setSurname(String surname){
        this.surname=surname;
    }
    public void setLogin(String login){
        this.login=login;
    }
    public void setPassword(String password){
        this.password=password;
    }
    @Override
    public String toString() {
        return "Full name : " + surname + ' ' + name + "\n" + "login : " + login ;
    }
    public String getName(){
        return name;
    }
    public String getSurname(){
        return surname;
    }
    public String getLogin(){return login;}
    public String getPassword(){return password;}

    @Override
    public boolean equals(Object obj) {
        if(this==obj)
            return true;
        if (this.getClass()==obj.getClass()){
            Person p=(Person) obj;
            if (this.surname.equals(p.surname) && this.name.equals(p.name)
            && this.login.equals(p.login))
                return true;
            else
                return false;
        }
        return false;
    }

}
