// انتخاب دکمه
const backToTopButton = document.getElementById('backToTop');
const menuButton = document.getElementById('MenuButton');
const menuBar = document.getElementById('menuBar');
const closeButton = document.getElementById('closeButton');



// نمایش یا پنهان کردن دکمه بر اساس موقعیت اسکرول
window.addEventListener('scroll', () => {
    if (window.pageYOffset > 300) {
        backToTopButton.classList.add('show');
    } else {
        backToTopButton.classList.remove('show');
    }
});

// عملکرد کلیک روی دکمه
backToTopButton.addEventListener('click', () => {
    window.scrollTo({
        top: 0,
        behavior: 'smooth'
    });
});

document.addEventListener('DOMContentLoaded', function () {
    const header = document.getElementById('header');
    let lastScrollY = window.scrollY;

    window.addEventListener('scroll', () => {
        // اگر در بالای صفحه هستیم، هدر را نشان بده
        if (window.scrollY === 0) {
            header.classList.remove('header-hidden');
            return;
        }

        // اگر اسکرول به سمت پایین است، هدر را پنهان کن
        if (window.scrollY > lastScrollY) {
            header.classList.add('header-hidden');
        } else {
            // اگر اسکرول به سمت بالا است، هدر را نشان بده
            header.classList.remove('header-hidden');
        }

        lastScrollY = window.scrollY;
    });
});

menuButton.addEventListener('click', () => {
    document.body.classList.add('overflow-hidden');
    menuBar.classList.remove('invisible', 'opacity-0', '[&>div]:translate-x-full');
    menuBar.classList.add('visible', 'opacity-100', '[&>div]:translate-x-0', '[&>div]:w-5/6', 'z-top-of-chatbot-plus1');
});

// مدیریت کلیک خارج از منو
document.addEventListener('click', (e) => {
    if (!menuBar.contains(e.target) && !menuButton.contains(e.target)) {
        closeButton.click();
    }
});

function closeMenuBar() {

    document.body.classList.remove('overflow-hidden');
    menuBar.classList.remove('visible', 'opacity-100', '[&>div]:translate-x-0', '[&>div]:w-5/6', 'z-top-of-chatbot-plus1');
    menuBar.classList.add('invisible', 'opacity-0', '[&>div]:translate-x-full');

    document.body.classList.remove('overflow-hidden');
    menuBar.classList.remove('visible', 'opacity-100', '[&>div]:translate-x-0', '[&>div]:w-5/6', 'z-top-of-chatbot-plus1');
    menuBar.classList.add('invisible', 'opacity-0', '[&>div]:translate-x-full');

    closeMenuSub();
}

function closeMenuSub() {

    // بستن تمام sub-menu ها
    document.querySelectorAll('input[type="checkbox"]').forEach(checkbox => {
        checkbox.checked = false;
    });
}

function OpenCloseSubCat(num) {
    var childrenCatDiv = $('#SubCat_' + num);

    if (childrenCatDiv.hasClass('hidden')) {
        childrenCatDiv.removeClass('hidden');
        $('#CharSubCat_' + num).addClass('rotate-180');
    }
    else {
        childrenCatDiv.addClass('hidden');
        $('#CharSubCat_' + num).removeClass('rotate-180');
    }

}

//function showFooter(nameShow) {
//    var arrowSVG = $('#arrow' + nameShow);
//    var component = $('#Link' + nameShow);

//    if (arrowSVG.hasClass('rotate-180')) {
//        arrowSVG.removeClass('rotate-180');
//    }
//    else {
//        arrowSVG.addClass('rotate-180');
//        $(component).clone().appendTo('#Cap' + nameShow);
//    }
//}

function showFooter(nameShow) {
    var $arrow = $('#arrow' + nameShow);
    var $container = $('#Cap' + nameShow);
    var dataKey = 'footerClone_' + nameShow;

    // بررسی وضعیت
    if ($arrow.hasClass('rotate-180')) {
        // بستن
        $arrow.removeClass('rotate-180');

        // پاک کردن از DOM و حذف reference
        var $clone = $arrow.data(dataKey);
        if ($clone) {
            $clone.remove();
            $arrow.removeData(dataKey);
        }
    } else {
        // باز کردن
        $arrow.addClass('rotate-180');

        // ایجاد clone و ذخیره reference
        var $clone = $('#Link' + nameShow).clone().removeAttr('id');
        $container.append($clone);
        $arrow.data(dataKey, $clone);
    }
}