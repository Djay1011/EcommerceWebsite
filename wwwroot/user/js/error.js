const form = document.querySelector("form"),
      emailfield = form.querySelector(".email-field"),
      emailInput = emailfield.querySelector(".email"),
      passfield = form.querySelector(".create-password"),
      passInput = passfield.querySelector(".password");


form.addEventListener('submit', (e) =>{
    e.preventDefault();

    checkInput();
})

function checkInput(){
    const emailvalue = email.emailvalue.trim();
    const passwordvalue = password.emailvalue.trim();


    if(emailvalue === '') {
        setErrorFor(email, 'Email cannot be blank');
    }else{
        setSucessFor(email);
    }
}

function setErrorFor(input,message){
    const formcontrol = input.parentElement;
    const small = formC
}


