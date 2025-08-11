const ZKLib = require('node-zklib');

async function getLogs() {
    const device = new ZKLib('192.168.1.201', 4370, 10000, 4000); // cambia la IP

    try {
        // Conectar
        await device.createSocket();

        // Leer logs
        const logs = await device.getAttendances();
        console.log("Logs:", logs.data);

        // Desconectar
        await device.disconnect();
    } catch (e) {
        console.error("Error al conectar:", e);
    }
}

getLogs();
