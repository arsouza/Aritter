/// <binding BeforeBuild='jshint' ProjectOpened='watch' />
(() => {
  'use strict';

  const gulp = require('gulp');
  const jshint = require('gulp-jshint');
  const stylish = require('jshint-stylish');
  const htmlmin = require('gulp-htmlmin');
  const ngTemplate = require('gulp-ng-template');
  const uglify = require('gulp-uglifyjs');
  const cssmin = require('gulp-cssmin');
  const rename = require('gulp-rename');
  const less = require('gulp-less');
  const clean = require('gulp-clean');
  const connect = require('gulp-connect');
  const watch = require('gulp-watch');
  const shell = require('gulp-shell');
  const concat = require('gulp-concat');
  const inject = require('gulp-inject');

  gulp.task('templates', () =>
    gulp.src(['app/**/*.html'])
      .pipe(htmlmin({ collapseWhitespace: true, collapseBooleanAttributes: true, quoteCharacter: '"' }))
      .pipe(ngTemplate({
        moduleName: 'aritter',
        filePath: 'templates.js'
      }))
      .pipe(gulp.dest('app/shared/templates'))
  );

  gulp.task('jshint', () =>
    gulp.src(['app/**/*.js', '!app/shared/templates/templates.js'])
      .pipe(jshint())
      .pipe(jshint.reporter(stylish))
      .pipe(jshint.reporter('fail'))
  );

  gulp.task('less', () => {
    gulp.src('assets/less/app.less')
      .pipe(less())
      .pipe(gulp.dest('assets/css'));
  });

  gulp.task('cssmin', ['less'], () => {
    gulp.src(['assets/css/**/*.min.css'], { read: false })
      .pipe(clean({ force: true }));

    gulp.src(['assets/css/**/*.css', '!assets/css/**/*.min.css'])
      .pipe(cssmin())
      .pipe(rename({ suffix: '.min' }))
      .pipe(gulp.dest('assets/css'));
  });

  gulp.task('setup', shell.task(['npm install', 'bower install'], {
    verbose: true
  }));

  gulp.task('run', ['jshint', 'setup'], () =>
    connect.server({
      root: 'src',
      port: 8888
    })
  );

  gulp.task('watch', () => {
    gulp.watch(['assets/less/**/*.less'], ['cssmin']);
    gulp.watch(['app/**/*.html', '!app/index.html'], ['templates']);
    gulp.watch(['app/**/*.js', '!app/shared/templates/templates.js'], ['jshint']);
  });

  gulp.task('default', ['watch']);
})();
