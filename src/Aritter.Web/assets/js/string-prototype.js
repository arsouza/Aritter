String.format = function () {
  var s = arguments[0];
  for (var i = 0; i < arguments.length - 1; i++) {
    var reg = new RegExp('\\{' + i + '\\}', 'gm');
    s = s.replace(reg, arguments[i + 1]);
  }

  return s;
};

String.isNullOrEmpty = function () {
  var str = arguments[0];
  return !str || str === '';
};

String.concat = function () {

  var str = '';

  for (var i = 0 ; i < arguments.length; i++) {
    str += arguments[i];
  }
  return str;
}

var join = function (separator, values) {
  if (values && values.length > 0) {

    var result = '';

    for (var index = 0; index < values.length; index++) {
      result += values[index];

      if (index < values.length - 1) {
        result += separator;
      }
    }

    return result;
  }
  return '';
};

String.join = function (separator, transform, values) {
  if (arguments.length === 2) {
    return join(arguments[0], arguments[1]);
  }

  if (values && values.length > 0) {

    var result = '';

    for (var index = 0; index < values.length; index++) {
      result += transform(values[index]);

      if (index < values.length - 1) {
        result += separator;
      }
    }

    return result;
  }
  return '';
};

String.prototype.padLeft = function (paddingChar, length) {

  var s = this;

  if ((this.length < length) && (paddingChar.toString().length > 0)) {
    for (var i = 0; i < (length - this.length) ; i++) {
      s = paddingChar.toString().charAt(0).concat(s);
    }
  }

  return s;
};

String.prototype.padRight = function (paddingChar, length) {

  var s = this;

  if ((this.length < length) && (paddingChar.toString().length > 0)) {
    for (var i = 0; i < (length - this.length) ; i++) {
      s = s.concat(paddingChar.toString().charAt(0));
    }
  }

  return s;
};

String.ifNull = function (str, other) {

  if (String.isNullOrEmpty(str)) {
    return other;
  }
  return str;
};

String.prototype.contains = function (it) {
  return this.indexOf(it) !== -1;
};

String.prototype.replaceAll = function (find, replace) {
  return this.replace(new RegExp(find.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1"), 'g'), replace);
};
