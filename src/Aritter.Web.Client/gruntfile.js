module.exports = function (grunt) {

  require('load-grunt-tasks')(grunt);
  grunt.loadNpmTasks('grunt-contrib-clean');
  grunt.loadNpmTasks('grunt-contrib-uglify');

  grunt.initConfig({
    jshint: {
      options: {
        jshintrc: '.jshintrc'
      },
      app: ['wwwroot/app/**/*.js', '!wwwroot/app/**/*min.js']
    },
    clean: {
      build: {
        src: ['wwwroot/app/aritter.min.js', 'wwwroot/app/aritter.map', 'wwwroot/assets/css/aritter.min.css']
      }
    },
    uglify: {
      options: {
        sourceMap: true,
        sourceMapIncludeSources: true,
        sourceMapName: 'wwwroot/app/aritter.map'
      },
      app: {
        files: {
          'wwwroot/app/aritter.min.js': ['wwwroot/app/**/*.js', '!wwwroot/app/**/*min.js']
        }
      }
    }
  });
};
