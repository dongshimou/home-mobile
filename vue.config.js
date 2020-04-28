const axios = require('axios')
const express = require("express")
const app = express()
const router = express.Router()
app.use('/proxy', router)

module.exports = {
  productionSourceMap: false,
  devServer: {
    before(app) {
      app.get('/proxy/live', (req, res) => {
        const url = 'https://api.live.bilibili.com/xlive/web-room/v1/index/getInfoByRoom'
        let burl = url + req.url.replace('/proxy/live', '')
        axios.get(burl, {
          headers: {
            referer: 'https://live.bilibili.com',
            rrigin: 'live.bilibili.com'
          }
        }).then(
          response => {
            res.json(response.data)
          }
        ).catch(e => {
          console.log(e)
        })
      })
    }
  }
}