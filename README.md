# 🔥 Gas Level Monitoring API

An ASP.NET Core Web API for monitoring the levels of hazardous gases such as LPG, Propane, Hydrogen, Methane, Smoke, CO, Alcohol, Ethanol, and Benzine.

This API checks submitted gas levels against predefined safety thresholds and returns one of three statuses: `SAFE`, `CAUTION`, or `DANGER`.

---

## 🚀 Features

- Monitor 8 common working gases.
- Submit gas level and get real-time status:
  - `SAFE` – Level is **below** the minimum threshold.
  - `CAUTION` – Level is **within** the acceptable range.
  - `DANGER` – Level is **above** the maximum threshold.
- Lightweight and fast — ideal for IoT and sensor-based systems.

---

## 📦 Gases Monitored

| Gas        | Description           |
|------------|-----------------------|
| LPG        | Liquefied Petroleum Gas |
| Propane    | Highly flammable gas  |
| Hydrogen   | Colorless, odorless gas |
| Methane    | Natural gas component |
| Smoke      | Suspended particulates |
| CO         | Carbon Monoxide       |
| Alcohol    | Ethanol and related vapors |
| Benzine    | Petroleum solvent     |

---

## 📄 API Endpoints

### ✅ Check Gas Level

**POST** `/api/gas/check`

**Request Body**:
```json
{
  "name": "Methane",
  "level": 1.2
}
```
**Response**
```yaml
Gas: Methane, Level: 1.2, Status: CAUTION
```
## 🛠️ Technologies
- ASP.NET Core Web API

- C#

- REST
