$(document).ready(function () {
    $(".categories").hide();
    $("h3 span").on('click', function () {
        slideToggle(this);
    });

    $("a.add-category").on('click', function () {
        var parent = $(this).parent();
        if (parent[0].tagName == "H3") {
            var baseCat = parent.siblings('ul').first();
            baseCat.append('<li><input type="text" placeholder="Наименование категории" required /><a href="#" class="sticks save-category">💾</a></li>');
            if (parent.children('span').data('status') == false || parent.children('span').data('status') == null) {
                slideToggle(parent.children('span'));
            }

        } else if (parent[0].tagName == "LI") {
            var baseCat = parent.first();
            var nameCategory = baseCat.contents().filter((i, el) => el.nodeType === 3).text();
            var newH3 = baseCat.replaceWith('<h3>' + nameCategory +
                '<span class="expand">🔽</span>' +
                '<a href="#" class="sticks edit-category">🔀</a>' +
                '<a href="#" class="sticks del-category">🞬</a>' +
                '<a href="#" class="sticks edit-category">🖉</a>' +
                '<a href="#" class="sticks add-category">🞦</a>' +
                '</h3 >' +
                '<ul class="categories" style="">' +
                '<input type="text" placeholder="Наименование категории" required /><a href="#" class="sticks save-category">💾</a>' +
                '</ul>');
        }
        return false;
    });
    function slideToggle(obj) {
        if (!$(obj).data('status')) {
            $(obj).html('&#128316;');
            $(obj).data('status', true);
        }
        else {
            $(obj).html('&#128317;');
            $(obj).data('status', false);
        }
        $(obj).parent().next().slideToggle();
    }

});