let counter = 0;

window.onload = function(){
    let page = document.location.pathname.substring(1);
    page = page.replace(".html", "");
    page = page.replace("index", "");
    
    document.getElementById(`nav${page}`).classList.add("active");
    document.getElementById('countern').innerText = counter = parseInt(window.localStorage.getItem('count')) || 0;

    document.getElementById("counter").addEventListener("click", function(){
        counter += 1;            
        document.getElementById("countern").innerText = counter;
        window.localStorage.setItem('count', counter);

        if(counter === 420){
            alert(atob("UGVyY2joIGNsaWNjaGkgNDIwIHZvbHRlIGlsIG1pbyBub21lPz8/"));
            counter = 0;
        }
        console.log(counter);
    });
};

function refresh(){
    counter = 0;
    window.localStorage.setItem('count', counter);
    window.location.reload();
}