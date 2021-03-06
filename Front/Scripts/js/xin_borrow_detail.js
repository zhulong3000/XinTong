(function() {
  requirejs.config({
    basrUrl: '../js',
    paths: {
      jquery: 'libs/jquery',
      angular: 'libs/angular.min',
      owl: 'libs/owl.carousel.min'
    },
    shim: {
      "owl": {
        deps: ["jquery"]
      }
    }
  });

  requirejs(['jquery', 'owl', './app/main'], function($) {
    var others_products_owl;
    others_products_owl = $("#others_products_list").owlCarousel({
      items: 3,
      autoPlay: 5000,
      itemsTablet: [600, 3],
      itemsMobile: false,
      pagination: false
    });
    $("#prev").on("click", function() {
      others_products_owl.trigger("owl.prev");
    });
    $("#next").on("click", function() {
      others_products_owl.trigger("owl.next");
    });
  });

}).call(this);
