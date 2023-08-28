const but = document.getElementById('sidebtn');
const close = document.getElementById('cancel');
const nav = document.getElementById('navs');

if(but){
    but.addEventListener('click', () =>{
        nav.classList.toggle('active');
    })
}

if(close){
    close.addEventListener('click', () =>{
        nav.classList.remove('active');
    })
}