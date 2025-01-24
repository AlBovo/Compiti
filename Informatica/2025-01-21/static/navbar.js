let counter = 0;

window.onload = function(){
    let page = document.location.pathname.substring(1);
    page = page.replace(".html", "");
    page = page.replace("index", "");
    document.getElementById(`nav${page}`).classList.add("active");

    document.getElementById("nome").addEventListener("click", function(){
        counter += 1;
        if(counter === 420){
            alert(atob("UGVyY2joIGNsaWNjaGkgNDIwIHZvbHRlIGlsIG1pbyBub21lPz8/"));
            counter = 0;
        }
        console.log(counter);
    });
};