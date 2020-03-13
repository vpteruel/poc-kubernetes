process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = '0';

const request = require('request');

setInterval(function () {
  request('https://localhost:5001/values', { json: true }, (err, res, body) => {
    if (err) { return console.log(err); }
    let date = new Date();
    console.log(`${date.getHours()}:${date.getMinutes()}:${date.getSeconds()}.${date.getMilliseconds()} | ${body}`);
  });
}, 200);
