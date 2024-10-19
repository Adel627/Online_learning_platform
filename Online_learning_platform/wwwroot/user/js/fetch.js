// Fetch main
fetch('../include/main.html')
.then(response => response.text())
.then(data => {
    document.getElementById('main').innerHTML = data;
});


// Fetch header
fetch('../include/header.html')
.then(response => response.text())
.then(data => {
    document.getElementById('header').innerHTML = data;
});


// Fetch footer
fetch('../include/footer.html')
.then(response => response.text())
.then(data => {
    document.getElementById('footer').innerHTML = data;
});
