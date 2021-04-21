window.onload = function(){
    var formHandle = document.forms.teacherForm;

    formHandle.onsubmit = validateForm;
    function validateForm() {
        var lname = formHandle.lname;
        var fname = formHandle.fname;
        var number = formHandle.number;
        var salary = formHandle.salary;
        
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
    }
}