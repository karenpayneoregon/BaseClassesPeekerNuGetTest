# Protected connection

When working without a secure connection a connection is created by passing in 
the path and file name to AccessConnection class which sets the provider.

With the secure connection in app.config the provider, path and file name along with 
the database password are already ready exception for decryption.