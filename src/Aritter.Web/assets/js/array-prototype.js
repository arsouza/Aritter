Array.prototype.firstOrDefault = function (predicate) {
  var source = this;

  if (predicate) {
    for (var index = 0; index < source.length; index++) {
      if (predicate(source[index])) {
        return source[index];
      }
    }
  }
  return undefined;
};

Array.prototype.any = function (predicate) {

  var source = this;

  if (predicate) {
    for (var index = 0; index < source.length; index++) {
      if (predicate(source[index])) {
        return true;
      }
    }
    return false;
  }
  return source.length > 0;

};

Array.prototype.removeAt = function (index) {
  this.splice(index, 1);
};

Array.prototype.select = function (selector) {

  var source = this;
  var result = [];

  if (selector) {
    for (var index = 0; index < source.length; index++) {
      result.push(selector(source[index]));
    }
  }
  return result;
};

Array.prototype.where = function (predicate) {
  var source = this;
  var result = [];

  if (predicate) {
    for (var index = 0; index < source.length; index++) {
      var obj = source[index];

      if (predicate(obj)) {
        result.push(obj);
      }
    }
  }
  return result;
};

Array.prototype.selectMany = function (selector) {

  var source = this;
  var result = [];

  if (selector) {
    for (var index = 0; index < source.length; index++) {
      result = result.concat(selector(source[index]));
    }
  }
  return result;

};

Array.prototype.all = function (predicate) {

  var source = this;

  if (predicate) {
    for (var index = 0; index < source.length; index++) {
      if (!predicate(source[index])) {
        return false;
      }
    }
  }

  return true;
};

Array.prototype.remove = function (element, predicate) {

  var source = this;
  var _index = -1;

  if (predicate) {
    for (var index = 0; index < source.length; index++) {
      if (predicate(source[index])) {
        _index = index;
        break;
      }
    }
  }
  else if (element) {
    _index = source.indexOf(element);
  }

  if (_index > -1) {
    source.removeAt(_index);
  }
  return _index;
};

Array.prototype.gocil_forEach = function (predicate) {
  var source = this;

  if (predicate) {
    for (var index = 0; index < source.length; index++) {
      predicate(source[index]);
    }
  }
};
