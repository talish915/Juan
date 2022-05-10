$(document).ready(function () {
    $(document).on("click", ".addToBasket", function (e) {
        e.preventDefault();
        let url = $(this).attr("href");
        fetch(url).then(res => {
            return res.text()
            console.log(url)
        }).then(data => {
            $(".minicart-inner").html(data);
            UpdateBasketCount()
        })
    })

    $(document).on("click", ".addbasketbtn", function (e) {
        e.preventDefault()
        let url = $(this).attr("href");
        let count = $("#productcount").val();

        var e = document.getElementById("colorids");
        var colorID = e.options[e.selectedIndex].value;

        var e = document.getElementById("sizeids");
        var sizeID = e.options[e.selectedIndex].value;

        console.log(colorID)
        console.log(sizeID)

        url = url + "?count=" + count + "&colorid=" + colorID + "&sizeid=" + sizeID;
        fetch(url).then(response => {
            return response.text();
        }).then(data => {
            $(".minicart-inner").html(data)
            UpdateBasketCount()
        })
    })

    function UpdateBasketCount() {
        fetch("/basket/GetBasketCount").then(
            response => response.json()
        ).then(data => {
            $('.notification').text(data.count);
        })
    }

    $(document).on("click", ".productdetail", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url).then(response => response.text())
            .then(data => {
                $(".modal-content").html(data)

                $('.pro-nav').slick({
                    slidesToShow: 4,
                    asNavFor: '.product-large-slider',
                    arrows: false,
                    focusOnSelect: true
                });

                $('.product-large-slider').slick({
                    fade: true,
                    arrows: false,
                    asNavFor: '.pro-nav'
                });

                $('.img-zoom').zoom();

                $("#productQuickModal").modal("show")
            })
    })
    $(document).on("click", ".qtybtn", function (e) {
        e.preventDefault()
        let url = $(this).attr("href");
        var count = $(this).parent().find('input').val();
        var id = $(this).parent().find('input').attr("data-id");

        if ($(this).hasClass("dec")) {

            if (count != 0) {
                count--;
            }
        }
        else {
            count++;
        }

        fetch("Basket/Update" + "?id=" + id + "&count=" + count).then(response => {

            fetch("Basket/GetBasket").then(response => response.text())
                .then(data => $(".minicart-inner").html(data))
            return response.text()

        }).then(data => $(".basketContainer").html(data))

        $(this).parent().find('input').val(parseFloat(count));
    })


    $(document).on("click", ".deletecard", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url).then(response => {
            fetch("Basket/GetBasket").then(response => response.text()).then(data => $(".header-cart").html(data))

            return response.text()
        }).then(data => {
            $(".basketContainer").html(data)
            UpdateBasketCount()
        })
    })

    $(document).on("click", ".deletebasket", function (e) {
        e.preventDefault();

        let url = $(this).attr("href");

        fetch(url).then(response => {
            fetch("Basket/GetCard").then(response => response.text()).then(data => $(".basketContainer").html(data))

            return response.text()
        }).then(data => {
            $(".minicart-inner").html(data)
            UpdateBasketCount()
        })
        
    })

    $(".minicart-btn").on('click', function () {
        $("body").addClass('fix');
        $(".minicart-inner").addClass('show')
    })

    $(document).on("click", ".offcanvas-close, .minicart-close,.offcanvas-overlay", function () {
        $("body").removeClass('fix');
        $(".offcanvas-search-inner, .minicart-inner").removeClass('show')
    })

    $('.pro-nav').slick({
        slidesToShow: 4,
        asNavFor: '.product-large-slider',
        arrows: false,
        focusOnSelect: true
    });

    $('.product-large-slider').slick({
        fade: true,
        arrows: false,
        asNavFor: '.pro-nav'
    });

    $('.img-zoom').zoom();
})