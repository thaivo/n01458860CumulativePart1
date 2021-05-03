function addEvent(checkbox, object) {
    checkbox.addEventListener('change', function () {
        if (this.checked) {
            object.style.display = "block";
        } else {
            object.style.display = "None";
        }
    });
}
function searchTeacher() {
    formHandle = document.forms.searchForm;
    var hiredateCheckBox = formHandle.hiredateCheckBox;
    var nameCheckBox = formHandle.nameCheckBox;
    var salaryCheckBox = formHandle.salaryCheckBox;

    var nameGroup = document.getElementById("name");
    var hiredateGroup = document.getElementById("hiredate");
    var salaryGroup = document.getElementById("salary");

    nameGroup.style.display = "none";
    hiredateGroup.style.display = "none";
    salaryGroup.style.display = "none";

    addEvent(nameCheckBox, nameGroup);
    addEvent(hiredateCheckBox, hiredateGroup);
    addEvent(salaryCheckBox, salaryGroup);

}
