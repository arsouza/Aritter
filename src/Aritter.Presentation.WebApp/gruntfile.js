/// <binding BeforeBuild='default' />
module.exports = function (grunt) {

    var pkg = grunt.file.readJSON('package.json');
    var project = grunt.file.readJSON('project.json');

    var webroot = project.webroot;

    require('load-grunt-tasks')(grunt);
    grunt.loadNpmTasks('grunt-contrib-clean');
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-less');
    grunt.loadNpmTasks('grunt-angular-templates');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-injector');
    grunt.loadNpmTasks('grunt-csssplit');
    grunt.loadNpmTasks('grunt-contrib-cssmin');

    grunt.initConfig({
        jshint: {
            options: {
                jshintrc: '.jshintrc'
            },
            all: [webroot + '/app/**/*.js', '!' + webroot + 'app/**/*min.js']
        },
        clean: {
            build: {
                src: [webroot + '/app/**/*.min.js', webroot + '/app/**/*.min.js.map', webroot + '/assets/css/aritter.min.css']
            }
        },
        uglify: {
            options: {
                sourceMap: true,
                sourceMapIncludeSources: true
            },
            build: {
                files: [{
                    expand: false,
                    src: [webroot + '/app/app.js', '!' + webroot + 'app/app.min.js'],
                    dest: webroot + '/app/app.min.js'
                }, {
                    expand: false,
                    src: [webroot + '/app/components/main/mainController.js', '!' + webroot + 'app/components/main/mainController.min.js'],
                    dest: webroot + '/app/components/main/mainController.min.js'
                }, {
                    expand: false,
                    src: [webroot + '/app/components/home/homeController.js', '!' + webroot + 'app/components/home/homeController.min.js'],
                    dest: webroot + '/app/components/home/homeController.min.js'
                }]
            },
            publish: {
                files: [{
                    expand: false,
                    src: [webroot + '/app/**/*.js', '!' + webroot + 'app/**/*min.js'],
                    dest: webroot + '/app/aritter.min.js'
                }]
            }
        },
        cssmin: {
            target: {
                files: [{
                    expand: true,
                    src: [webroot + '/assets/css/app.css', '!' + webroot + '/assets/css/app.min.css'],
                    ext: '.min.css'
                }, {
                    expand: true,
                    src: [webroot + '/assets/css/demo.css', '!' + webroot + '/assets/css/demo.min.css'],
                    ext: '.min.css'
                }]
            }
        },
        injector: {
            options: {
                addRootSlash: false
            },
            build: {
                files: [{
                    src: [webroot + '/app/**/*.js', '!' + webroot + '/app/**/*.min.js'],
                    dest: webroot + '/index.html'
                }]
            },
            publish: [{
                src: [webroot + '/app/aritter.min.js'],
                dest: webroot + '/index.html'
            }]
        },
        ngtemplates: {
            materialAdmin: {
                src: [webroot + '/assets/template/**.html', webroot + '/assets/template/**/**.html'],
                dest: webroot + '/js/templates.js',
                options: {
                    htmlmin: {
                        collapseWhitespace: true,
                        collapseBooleanAttributes: true
                    }
                }
            }
        },
        less: {
            build: {
                options: {
                    paths: ["css"]
                },
                files: [{
                    src: [webroot + '/assets/less/app.less'],
                    dest: webroot + '/assets/css/app.css'
                }, {
                    src: [webroot + '/assets/less/demo.less'],
                    dest: webroot + '/assets/css/demo.css'
                }],
                cleancss: true
            }
        },
        watch: {
            styles: {
                files: [webroot + '/assets/less/**/*.less'], // which files to watch
                tasks: ['less', 'cssmin'],
                options: {
                    nospawn: true
                }
            }
        }
    });

    grunt.registerTask('build', ['clean', 'jshint', 'uglify:build', 'less', 'cssmin', 'ngtemplates', 'injector:build']);
    grunt.registerTask('publish', ['clean', 'jshint', 'uglify:publish', 'less', 'cssmin', 'ngtemplates', 'injector:publish']);

    grunt.registerTask('default', ['less', 'cssmin', 'ngtemplates']);
};
