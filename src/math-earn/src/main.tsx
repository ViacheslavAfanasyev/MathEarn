import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
//when imort rest.css - chakra styles get reset
//import './reset.css'
import App from './App.tsx';
import { Provider } from '@/components/ui/provider.tsx';

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <Provider>
      <App />
    </Provider>
  </StrictMode>
);
