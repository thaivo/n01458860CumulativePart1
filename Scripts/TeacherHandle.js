
function updateTeacher(teacherId) {
    //goal: send a request which looks like this:
    //POST: http://localhost:50595/api/TeacherData/updateTeacher/{id}
    //with POST data of fname, lname, number, hiredate, salary

    var URL = "http://localhost:50595/api/TeacherData/updateTeacher/" + teacherId;
    var req = new XMLHttpRequest();

    var lname = document.getElementById("lname");
    var fname = document.getElementById("fname");
    var number = document.getElementById("number");
    var hiredate = document.getElementById("hiredate");
    var salary = document.getElementById("salary");

    var validateTeacher = validateTeacherInfo(lname, fname, number, hiredate, salary);
    if (!validateTeacher) return false;

    var teacherData = {
        "fname": fname.value,
        "lname": lname.value,
        "number": number.value,
        "salary": salary.value,
        "hiredate": hiredate.value
    };

    req.open("POST", URL, true);
    req.setRequestHeader("Content-Type", "application/json");
    req.onreadystatechange = function () {
        if (req.readyState == 4 && req.status == 200) {
            //the method returns nothing to render
        }
    }

    req.send(JSON.stringify(teacherData));
}

function validateTeacherForm() {
    var formHandle = document.forms.teacherForm;

    var lname = formHandle.lname;
    var fname = formHandle.fname;
    var number = formHandle.number;
    var hiredate = formHandle.hiredate;
    var salary = formHandle.salary;

    if (!validateTeacherInfo(lname, fname, number, hiredate, salary)) {
        return false;
    }
}

function validateTeacherInfo(lname, fname, number, hiredate, salary) {
    console.log('last name: ' + lname.value);

    if (fname.value === "" || fname.value === null) {
        fname.style.background = "red";
        fname.focus();
        return false;
    }
    if (lname.value === "" || lname.value === null) {
        lname.style.background = "red";
        lname.focus();
        return false;
    }
    var numberRegex = /^[A-Z]\d{3}/;
    if (number.value === "" || number.value === null) {
        number.style.background = "red";
        number.focus();
        return false;
    }
    else if (!numberRegex.test(number.value)) {
        number.style.background = "red";
        number.value = "Wrong syntax of teacher number"
        number.focus();
        return false;
    }
    var dateRegex = /(19|20)\d{2}\-(0\d{1}|1[0-2])\-([0-2]\d{1}|3[0-1])/;
    if (hiredate.value === "" || hiredate.value === null) {
        hiredate.style.background = "red";
        hiredate.focus();
        return false;
    }
    else if (!dateRegex.test(hiredate.value)) {
        hiredate.style.background = "red";
        hiredate.value = "please correct date with format yyyy-mm-dd ";
        hiredate.focus();
        return false;
    }

    var salaryRegex = /^\d*(\.)?\d+$/;
    if (salary.value === "" || salary.value === null) {
        salary.style.background = "red";
        salary.focus();
        return false;
    }
    else if (!salaryRegex.test(salary.value)) {
        salary.style.background = "red";
        salary.value = "please correct salary";
        salary.focus();
        return false;
    }
    return true;
}