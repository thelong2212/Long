$(document).ready(function () {
    $('.your-class').slick({
        dots: true,
        infinite: true,
        fade: true,
        cssEase: 'linear',
        autoplay: true,
        autoplaySpeed: 2000,
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
        autoplay: true,
        autoplaySpeed: 2000,
        asNavFor: '.slider-nav'
    });
    $('.slider-nav').slick({
        slidesToShow: 3,
        slidesToScroll: 1,
        asNavFor: '.slider-for',
        centerMode: true,
        autoplay: true,
        autoplaySpeed: 2000,
        focusOnSelect: true
    })

    $('.responsive').slick({
        dots: false,
        infinite: true,
        speed: 300,
        slidesToShow: 2,
        autoplay: true,
        autoplaySpeed: 2000,
        slidesToScroll: 2,
        responsive: [
            {
                breakpoint: 1024,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2,
                    infinite: true,
                    dots: false,
                   
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2,
                  
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 2,
                  
                }
            }
            // You can unslick at a given breakpoint now by adding:
            // settings: "unslick"
            // instead of a settings object
        ]
    });

    //$("#searchID").autocomplete({
    //    minLength: 0,
    //    source: function (request, response) {
    //        $.ajax({
    //            url: "/Home/ListName",
    //            dataType: "json",
    //            data: {
    //                keywword: request.term
    //            },
    //            success: function (res) {
    //                response(res.data);
    //            }
    //        });
    //    },
    //    focus: function (event, ui) {
    //        $("#searchID").val(ui.item.label);
    //        return false;
    //    },
    //    select: function (event, ui) {
    //        $("#searchID").val(ui.item.label);
    //        return false;
    //    }
    //})
    //    .autocomplete("instance")._renderItem = function (ul, item) {
    //        return $("<li>")
    //            .append("<div>" + item.label + "</div>")
    //            .appendTo(ul);
    //    };
});