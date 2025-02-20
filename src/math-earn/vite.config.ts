import { defineConfig } from 'vite';
import react from '@vitejs/plugin-react';
import tsconfigPaths from 'vite-tsconfig-paths';

const PORT = parseInt(process.env.VITE_PORT || '5173', 10);

// https://vite.dev/config/
export default defineConfig({
  plugins: [react(), tsconfigPaths()],
  server: {
    port: PORT,
    strictPort: true,
    host: true,
    origin: `http://0.0.0.0:${PORT}`,
  },
});
