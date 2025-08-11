const ZKLib = require('node-zklib');
(async () => {
    const device = new ZKLib('192.168.1.201', 4370, 10000, 4000);
    await device.createSocket();
    const logs = await device.getAttendances();
    console.log(logs.data);
    await device.disconnect();
})();
