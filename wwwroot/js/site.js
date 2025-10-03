$(function() {
  $('.hero-slider').slick({
      dots: true,
      arrows: true,
      infinite: true,
      autoplay: true,
      autoplaySpeed: 6000,
      fade: true,
      slidesToShow: 1,
      slidesToScroll: 1,
      adaptiveHeight: false,
      prevArrow: '<button type="button" class="slick-prev" aria-label="Previous slide">‹</button>',
      nextArrow: '<button type="button" class="slick-next" aria-label="Next slide">›</button>'
  });
});
