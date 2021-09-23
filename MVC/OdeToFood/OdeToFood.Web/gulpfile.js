
const { src, dest, series, parallel, watch } = require('gulp')
const { scss, scssLint } = require('./gulp/sass/sass.gulpfile')


function watcher () {
  watch('src/scss/**/*.scss', series(scssLint, scss))
}

exports.scss = series(scssLint, scss)
exports.scssLint = scssLint
exports.watch = series(watcher)