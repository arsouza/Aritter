/// <binding BeforeBuild='min' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify"),
    project = require("./project.json");

var paths = {
  webroot: "./" + project.webroot + "/"
};

paths.js = paths.webroot + "app/**/*.js";
paths.minJs = paths.webroot + "app/**/*.min.js";
paths.css = paths.webroot + "assets/css/**/*.css";
paths.minCss = paths.webroot + "assets/css/**/*.min.css";
paths.concatJsDest = paths.webroot + "app/aritter.min.js";
paths.concatCssDest = paths.webroot + "assets/css/aritter.min.css";

gulp.task("clean:js", function (cb) {
  rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
  rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
  gulp.src([paths.js, "!" + paths.minJs], { base: "." })
      .pipe(concat(paths.concatJsDest))
      .pipe(uglify())
      .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
  gulp.src([paths.css, "!" + paths.minCss])
      .pipe(concat(paths.concatCssDest))
      .pipe(cssmin())
      .pipe(gulp.dest("."));
});

gulp.task("min", ["min:js", "min:css"]);
