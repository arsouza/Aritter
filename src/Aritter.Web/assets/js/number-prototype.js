Number.prototype.hasFlag = function (flag) {
  return (this & flag) === flag;
};
