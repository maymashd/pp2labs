import java.io.Serializable;
import java.util.HashSet;
import java.util.Vector;

public class Course implements Serializable {
private String name,id;
private Teacher teacher;
private Faculty faculty;
private HashSet<Student> students=new HashSet<>();
private int credit;
//Vector<CourseFile> courseFile;
public Course(){

}
public Course(String name,String id, Teacher teacher,int credit,Faculty faculty){
    this.name=name;
    this.teacher=teacher;
    this.credit=credit;
    this.id=id;
    this.faculty=faculty;
}
    public String getName() {

        return name;

    }

    public void setName(String name) {
        this.name = name;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public Teacher getTeacher() {
        return teacher;
    }

    public void setTeacher(Teacher teacher) {

        this.teacher = teacher;
    }

    public HashSet<Student> getStudents() {
        return students;
    }

    public void addStudent(Student student) {
        this.students.add(student);
    }

    public int getCreditsNumber() {

        return credit;

    }

    public void setCreditsNumber(int creditsNumber) {
        this.credit = creditsNumber;
    }

    public boolean equals(Object obj) {
       if (this.getClass()!=obj.getClass())
          return false;
        else{
            Course course2=(Course)obj;
        if (this.id.equals(course2.id)  )
            return true;
        else
            return false;
         }
    }

    @Override
    public String toString() {
        return "Name of course: "+name+"\n"+
                "Teacher of course: "+teacher+
                "Course id: "+id+"\n";

    }
}
