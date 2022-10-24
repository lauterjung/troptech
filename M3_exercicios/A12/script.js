const intervalTime = 1000;

var running = false;

var hour = 0;
var minute = 0;
var second = 0;

var intervalID = null;

function intervalManager(flag, animate, intervalTime) {
    if (flag) {
        running = true;
        intervalID = setInterval(animate, intervalTime);
    }
    else {
        running = false;
        clearInterval(intervalID);
    }
}

function runChronometer() {
    second += 1;

    if (second === 60) {
        minute += 1;
        second = 0;
    }
    if (minute === 60) {
        hour += 1;
        minute = 0;
    }
    if (hour === 24) {
        hour = 0;
    }
    document.querySelector("#chronometer").textContent =
        `${("0" + hour).slice(-2)}:${("0" + minute).slice(-2)}:${("0" + second).slice(-2)}`;
};

function startChronometer() {
    if (running) {
        return;
    }
    intervalManager(true, runChronometer, intervalTime);
}

function pauseChronometer() {
    intervalManager(false);
}

function resetChronometer() {
    intervalManager(false);
    hour = 0;
    minute = 0;
    second = 0;
    document.querySelector("#chronometer").textContent =
        `${("0" + hour).slice(-2)}:${("0" + minute).slice(-2)}:${("0" + second).slice(-2)}`;
}
