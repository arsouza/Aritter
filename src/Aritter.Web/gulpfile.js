/// <binding BeforeBuild='jsmin' ProjectOpened='watch' />
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
    gulp.src(['src/app/**/*.html', '!src/app/index.html'])
      .pipe(htmlmin({ collapseWhitespace: true, collapseBooleanAttributes: true, quoteCharacter: '"' }))
      .pipe(ngTemplate({
        moduleName: 'materialAdmin',
        filePath: 'templates.js'
      }))
      .pipe(gulp.dest('src/app/shared/templates'))
  );

  gulp.task('jshint', () =>
    gulp.src(['src/app/**/*.js', '!src/app/shared/templates/templates.js'])
      .pipe(jshint())
      .pipe(jshint.reporter(stylish))
      .pipe(jshint.reporter('fail'))
  );

  gulp.task('jsmin', ['jshint'], () => {
    gulp.src(['dist/app/app.js', 'dist/app/app.min.js', 'dist/app/app.js.map'], { read: false })
      .pipe(clean({ force: true }));

    gulp.src(['src/app/**/*.html', '!src/app/index.html'])
      .pipe(htmlmin({
        collapseWhitespace: true,
        collapseBooleanAttributes: true,
        quoteCharacter: '"'
      }))
      .pipe(ngTemplate({
        moduleName: 'materialAdmin',
        filePath: 'templates.js'
      }))
      .pipe(gulp.dest('src/app/shared/templates'));

    gulp.src(['src/app/app-module.js', 'src/app/app-constants.js', 'src/app/app-config.js', 'src/app/shared/**/*.js', 'src/app/components/**/*.js'])
      .pipe(concat('app.js'))
      .pipe(gulp.dest('dist/app/'))
      .pipe(uglify('app.min.js'))
      .pipe(gulp.dest('dist/app/'));
  });

  gulp.task('less', () => {
    gulp.src('src/assets/less/app.less')
      .pipe(less())
      .pipe(gulp.dest('src/assets/css'));

    gulp.src('src/assets/less/app.less')
      .pipe(less())
      .pipe(gulp.dest('dist/assets/css'));
  });

  gulp.task('cssmin', ['less'], () => {
    gulp.src(['src/assets/css/**/*.min.css', 'dist/assets/css/**/*.css'], { read: false })
      .pipe(clean({ force: true }));

    gulp.src(['src/assets/css/**/*.css', '!src/assets/css/**/*.min.css'])
      .pipe(cssmin())
      .pipe(rename({ suffix: '.min' }))
      .pipe(gulp.dest('src/assets/css'))
      .pipe(gulp.dest('dist/assets/css'));
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
    gulp.watch(['src/assets/less/**/*.less'], ['cssmin']);
    gulp.watch(['src/app/**/*.html', '!app/index.html'], ['templates']);
    gulp.watch(['src/app/**/*.js', '!src/app/shared/templates/templates.js'], ['jshint']);
  });

  gulp.task('build', ['jsmin', 'cssmin', 'templates'], () => {
    // It's not necessary to read the files (will speed up things), we're only after their paths:
    var sources = gulp.src(['dist/**/*.min.js', 'dist/**/*.min.css'], { read: false });

    return gulp.src('src/index.html')
      .pipe(inject(sources, {
        transform: function (filepath) {
          return '<script src="' + filepath.replace('/dist/', '') + '"></script>';
        }
      }))
      .pipe(gulp.dest('dist'));
  });

  gulp.task('default', ['watch']);
})();
