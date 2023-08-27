const navItems = document.querySelectorAll('.side-nav__item');
const removeClasses = () => {
    navItems.forEach(eachItem => {
        eachItem.classList.remove('side-nav__item-active');
    });
}

navItems.forEach(eachItem => {
    eachItem.addEventListener('click', function () {
        removeClasses();
        eachItem.classList.add('side-nav__item-active');
    });
});



const ctx2 = document.getElementById('myChart2');

var score1 = document.getElementById("score1");
var score2 = document.getElementById("score2");
var score3 = document.getElementById("score3");

var value1 = parseFloat(score1.textContent);
var value2 = parseFloat(score2.textContent);
var value3 = parseFloat(score3.textContent);

var totalScore = value1 + value2 + value3;

var labels = ["HTML Score", "CSS Score", "JavaScript Score"];

new Chart(ctx2, {
    type: 'doughnut',
    data: {
        labels: labels,
        datasets: [{
            data: [value1, value2, value3],
            borderRadius: 5,
            cutout: 80,
            backgroundColor: [
                'rgb(235, 124, 166)',
                'rgb(255, 172, 200)',
                'rgb(204, 111, 248)'
            ],
            hoverOffset: 4,
            spacing: 8
        }]
    },
    options: {
        plugins: {
            legend: {
                display: false
            }
        }
    }
});

var totalScoreElement = document.getElementById("total-score");
totalScoreElement.textContent = totalScore;



const themeToggleBtn = document.querySelector(".theme-toggler");
const dashborad = document.querySelector(".dashboard");
const toggleIcon = document.querySelector(".toggler-icon");

let isDark = false;
themeToggleBtn.onclick = () => {
    dashborad.classList.toggle("dark");
    themeToggleBtn.classList.toggle("active");
    isDark = !isDark;
};