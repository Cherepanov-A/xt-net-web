var navButtons = [],
    links = ['Task 9_4_1.html', 'Task 9_4_2.html', 'Task 9_4_3.html', 'Task 9_4_4.html'],
    idNum = +(document.getElementsByClassName('page-number')[0].textContent),
    pageNum,
    link = 0,
    timer,
    cntTimer,
    cntNum,
    cnt;

idNum = document.getElementsByClassName('page-number');
pageNum = idNum[0].textContent;
navButtons = document.getElementsByClassName('btn-secondary');
cnt = document.getElementById('counter');
function run() {
    timer = setInterval(moveForward, 3000);
    cntTimer = setInterval(countDown, 1000);
    cntNum = 3;
    cnt.textContent = '3';
    navButtons[0].onclick = function () {
        link = pageNum - 1;
        if (link < 0) {
            link = 3;
        }
        document.location = links[link];

    }
    navButtons[3].onclick = moveForward;
    function moveForward() {
        link = (+pageNum + 1);
        if (link > 3) {
            link = 0;
        }
        document.location = links[link];
    }
    navButtons[2].onclick = function () {
        clearInterval(timer);
        clearInterval(cntTimer);
    }
    navButtons[1].onclick = function () {
        timer = setInterval(moveForward, 3000);
        cntTimer = setInterval(countDown, 1000);
    }
    function countDown() {
        cntNum -= 1;
        if (cntNum < 0) {
            cntNum = 3;
        }
        cnt.textContent = cntNum;
    }    
}
run();
