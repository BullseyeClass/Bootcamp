


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

const ctx = document.getElementById('myChart');

new Chart(ctx, {
    type: 'bar',
    data: {
        labels: ['Jan', 'Feb', 'Mar', 'Apr', 'Mei', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Des'],
        datasets: [{
            label: 'Expense',
            data: [11, 3, 14, 7, 4, 15, 7, 9, 15, 13, 7, 14],
            borderWidth: 1,
            borderRadius: 30,
            barThickness: 12,
            backgroundColor: [
                'rgba(25,119,204, 0.9)'
            ],
            borderColor: [
                'rgba(114, 92, 255, 1)'
            ],
            hoverBackgroundColor: [
                'rgba(28, 30, 35, 1)'
            ],
            hoverBorderColor: [
                'rgba(28, 30, 35, 1)'
            ],
        }]
    },
    options: {
        responsive: true,
        scales: {
            y: {
                beginAtZero: true,
                ticks: {
                    // Include a dollar sign in the ticks
                    callback: function (value, index, ticks) {
                        return '$' + value + 'k';
                    },
                    stepSize: 5,
                },
            },
            x: {
                grid: {
                    display: false
                }
            }
        },
        plugins: {
            legend: {
                display: false,
                labels: {
                    font: {
                        size: 12,
                        family: "'Plus Jakarta Sans', sans-serif",
                        lineHeight: 18,
                        weight: 600
                    }
                }
            }
        }
    }
});

const ctx2 = document.getElementById('myChart2');

new Chart(ctx2, {
    type: 'doughnut',
    data: {
        datasets: [{
            label: 'Total Score',
            data: [78, 92, 35],
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


const themeToggleBtn = document.querySelector(".theme-toggler");
const dashborad = document.querySelector(".dashboard");
const toggleIcon = document.querySelector(".toggler-icon");

let isDark = false;
themeToggleBtn.onclick = () => {
    dashborad.classList.toggle("dark");
    themeToggleBtn.classList.toggle("active");
    isDark = !isDark;
};
