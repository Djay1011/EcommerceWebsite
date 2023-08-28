let Searchbtn =  document.querySelector('.Searchbtn');
let Closebtn = document.querySelector('.Closebtn');
let searchbox = document.querySelector('.searchbox');

Searchbtn.onclick = function(){
    searchbox.classList.add('active');
    Closebtn.classList.add('active');
    searchbox.classList.add('active');
}


Closebtn.onclick = function(){
    searchbox.classList.remove('active');
    Closebtn.classList.remove('active');
    searchbox.classList.remove('active');
}