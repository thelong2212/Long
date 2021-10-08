$(document).ready(function () {
    $('.your-class').slick({
        dots: true,
        infinite: true,
        speed: 500,
        fade: true,
        cssEase: 'linear'
    });

    var tabLinks = document.querySelectorAll(".tablinks");
    var tabContent = document.querySelectorAll(".product-list");

    tabLinks.forEach(function (el) {
        el.addEventListener("click", openTabs);
    });


    function openTabs(el) {
        var btn = el.currentTarget; // lắng nghe sự kiện và hiển thị các element
        var electronic = btn.dataset.electronic; // lấy giá trị trong data-electronic

        tabContent.forEach(function (el) {
            el.classList.remove("active");
        }); //lặp qua các tab content để remove class active

        tabLinks.forEach(function (el) {
            el.classList.remove("active");
        }); //lặp qua các tab links để remove class active

        document.querySelector("#" + electronic).classList.add("active");
        // trả về phần tử đầu tiên có id="" được add class active

        btn.classList.add("active");
        // các button mà chúng ta click vào sẽ được add class active
    }

    $('.slider-for').slick({
        slidesToShow: 1,
        slidesToScroll: 1,
        arrows: false,
        fade: true,
        asNavFor: '.slider-nav'
    });
    $('.slider-nav').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        asNavFor: '.slider-for',
        centerMode: true,
        focusOnSelect: true
    })
});