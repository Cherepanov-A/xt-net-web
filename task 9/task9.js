
var tmp = [];
var src = [];
var len;
var words = [];
var txt;
var wrdArr;
var result = [];
function rmDoubles(word) {
    for (let i = 0; i < word.length; i++) {
        len = tmp.push(word[i]);
        for (let j = i + 1; j < word.length; j++) {
            if (tmp[len - 1] == word[j]) {
                src.push(word[j]);
            }
        }
    }
    return src;
}
function getWords() {
    txt = document.getElementById('src91').value;
    words = txt.split(" ");
    return words;
}
function showRes() {
    wrdArr = getWords();
    wrdArr.forEach(element => {
        rmDoubles(element);
    });
    for (let index = 0; index < txt.length; index++) {
        src.forEach(element => {
            txt = txt.replace((element), '');
        });
    }
    document.getElementById('res91').value = txt;
}
document.getElementById('result').onclick = showRes;