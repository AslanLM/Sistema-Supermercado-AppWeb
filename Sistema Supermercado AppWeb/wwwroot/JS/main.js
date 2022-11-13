window.addEventListener('DOMContentLoaded', event => {

    // Navbar shrink function
    var navbarShrink = function () {
        const navbarCollapsible = document.body.querySelector('#mainNav');
        if (!navbarCollapsible) {
            return;
        }
        if (window.scrollY === 0) {
            navbarCollapsible.classList.remove('navbar-shrink')
        } else {
            navbarCollapsible.classList.add('navbar-shrink')
        }

    };

    // Shrink the navbar 
    navbarShrink();

    // Shrink the navbar when page is scrolled
    document.addEventListener('scroll', navbarShrink);

    // Activate Bootstrap scrollspy on the main nav element
    const mainNav = document.body.querySelector('#mainNav');
    if (mainNav) {
        new bootstrap.ScrollSpy(document.body, {
            target: '#mainNav',
            offset: 74,
        });
    };
});

const myslide = document.querySelectorAll('.myslide'),
	  dot = document.querySelectorAll('.dot');
let counter = 1;
slidefun(counter);

let timer = setInterval(autoSlide, 8000);
function autoSlide() {
	counter += 1;
	slidefun(counter);
}
function plusSlides(n) {
	counter += n;
	slidefun(counter);
	resetTimer();
}
function currentSlide(n) {
	counter = n;
	slidefun(counter);
	resetTimer();
}
function resetTimer() {
	clearInterval(timer);
	timer = setInterval(autoSlide, 8000);
}

function slidefun(n) {
	
	let i;
	for(i = 0;i<myslide.length;i++){
		myslide[i].style.display = "none";
	}
	for(i = 0;i<dot.length;i++) {
		dot[i].className = dot[i].className.replace(' active', '');
	}
	if(n > myslide.length){
	   counter = 1;
	   }
	if(n < 1){
	   counter = myslide.length;
	   }
	myslide[counter - 1].style.display = "block";
	dot[counter - 1].className += " active";
}

document.getElementById("opennav").addEventListener("click", function () {
    document.getElementById("mySidenav").style.width = "270px";
    document.getElementById("mainside").style.marginRight = "270px";
    document.body.style.backgroundColor = "rgba(0,0,0,0.4)";
})

document.getElementById("closebtn").addEventListener("click", function () {
    document.getElementById("mySidenav").style.width = "0";
    document.getElementById("mainside").style.marginRight = "0";
    document.body.style.backgroundColor = "";
})



// btnopens seccion

document.getElementById("btnopen").addEventListener("click", function () {
    document.getElementById("myseccion2").style.width = "100%";
    document.getElementById("myseccion").style.marginLeft = "100%";
    document.getElementById("myseccion2").style.display = "block";
    document.getElementById("myseccion").style.display = "none";
    document.getElementById("myseccion3").style.display = "none";
    document.getElementById("myseccion4").style.display = "none";
})

document.getElementById("btnopen2").addEventListener("click", function () {
    document.getElementById("myseccion3").style.width = "100%";
    document.getElementById("myseccion").style.marginLeft = "100%";
    document.getElementById("myseccion3").style.display = "block";
    document.getElementById("myseccion").style.display = "none";
    document.getElementById("myseccion2").style.display = "none";
    document.getElementById("myseccion4").style.display = "none";
})

document.getElementById("btnopen3").addEventListener("click", function () {
    document.getElementById("myseccion4").style.width = "100%";
    document.getElementById("myseccion").style.marginLeft = "100%";
    document.getElementById("myseccion4").style.display = "block";
    document.getElementById("myseccion").style.display = "none";
    document.getElementById("myseccion2").style.display = "none";
    document.getElementById("myseccion3").style.display = "none";
})

