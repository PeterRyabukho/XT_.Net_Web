var patern = /(page-\d\.\d\.html)/g;
var thisLocation = document.location.href;

var myLink = thisLocation.match(patern);

var myPageAdress = {
    pageOne: "page-1.1.html",
    pageTwo: "page-2.2.html",
    pageThree: "page-3.3.html",
    pageFour: "page-4.4.html",
    pageFive: "page-5.5.html",
};

var arrOfLinks =[];
for (var value of Object.values(myPageAdress)){
    arrOfLinks.push(value);
}

var value ="0";
var id;
var seconds = 5;

function listToNextPage(adress){
    function countDown(){
        document.getElementById("mySeconds").innerText = seconds +" sec";
        seconds--;

        if (seconds < 0){
            window.location = adress;
        }
    }

    countDown();
    id = setInterval(countDown, 1000);
}

choosePage(seconds);

function startMyTimer(){
    window.location = myLink[0];
}

function pauseMyTimer(){
    fromPauseResume();
    resume.disabled = false;
    value = mySeconds.textContent;
    clearInterval(id);
}

function resumeMyTimer(){
    fromPauseResume();
    resume.disabled = true;
    choosePage(value);
}

function moveBackPage(){
    var linkToFind = arrOfLinks.indexOf(myLink[0]);
    window.location = arrOfLinks[linkToFind - 1];
}

function choosePage(time){
     switch (myLink[0]){

        case 'page-1.1.html':
            listToNextPage(myPageAdress.pageTwo, time);
            break;
        case 'page-2.2.html':
            listToNextPage(myPageAdress.pageThree, time);
            break;
        case 'page-3.3.html':
            listToNextPage(myPageAdress.pageFour, time);
            break;
        case 'page-4.4.html':
            listToNextPage(myPageAdress.pageFive, time);
            break;
        case 'page-5.5.html':
                setTimeout(()=>(startAgainProgramOrClose()), 1000);
            break;
     }
 }


function startAgainProgramOrClose(){
    var valid = confirm("Do you want to repeat scrolling pages again (ok), or to exit this mode (cancel)?");
    if (valid == true){
        window.location = "page-1.1.html";

    } else if (valid == false){
        window.open('','_self').close();
    }
}
var pause = document.getElementById("pause");
pause.addEventListener("click", pauseMyTimer, false);

var start = document.getElementById("start");
start.addEventListener("click", startMyTimer, false);

var resume = document.getElementById("resume");
resume.addEventListener("click", resumeMyTimer, false);

var moveBack = document.getElementById("moveBack");
moveBack.addEventListener("click", moveBackPage, false);

function fromPauseResume(){
    if (pause.disabled == false){
        resume.disabled = true;
    } else if (pause.disabled == true){
        resume.disabled = false;
    }
}

function blockResumeOnStart(){
    pause.disabled == false;
    resume.disabled = true;
}

window.onload = blockResumeOnStart;