using DataAccess.Repositories;
using AutoMapper;
using DataAccess.Entities;
using System.Collections.Generic;
using FrankoMaps.Models;
using System.Linq;
using FrankoMaps.Algorithms;
using Microsoft.AspNetCore.Authorization;

namespace FrankoMaps.Services
{
    public class DistancesService
    {
        private readonly DistanceRepository repository;
        private readonly PointRepository _pointRepository;
        private readonly MapRepository _mapRepository;
        private readonly IMapper _mapper;

        private Dictionary<int, double[,]> graphs;
        private Dictionary<int, Dictionary<int, int>> allIndexes;
        private Dictionary<int, DijkstrasAlgorithm> algorithms;

        public DistancesService(DistanceRepository distanceRepository, IMapper mapper, PointRepository pointRepository, MapRepository mapRepository)
        {
            repository = distanceRepository;
            _mapper = mapper;
            _pointRepository = pointRepository;
            _mapRepository = mapRepository;

            CreateGraphs();
        }

        [Authorize(Roles = "Admin")]
        public void Create(DistanceViewModel map)
        {
            Distance newDistance = _mapper.Map<Distance>(map);

            repository.Create(newDistance);
        }
        public void UpdateDistance(DistanceViewModel distance)
        {
            Distance newDistance = _mapper.Map<Distance>(distance);

            repository.UpdateAsync(newDistance);
        }
        public DistanceViewModel GetDistance(int id)
        {
            Distance distance = repository.GetItem(id);
            DistanceViewModel distanceViewModel = _mapper.Map<DistanceViewModel>(distance);
            return distanceViewModel;
        }
        public List<DistanceViewModel> GetDistances()
        {
            List<Distance> distances = repository.GetItems();
            List<DistanceViewModel> distanceViewModels = _mapper.Map<List<DistanceViewModel>>(distances);
            return distanceViewModels;
        }
        public int[] GetTheShortestPath(int fromPId, int toPId, int mapId)
        {
            int from = allIndexes[mapId].FirstOrDefault(k => k.Value == fromPId).Key;
            int to = allIndexes[mapId].FirstOrDefault(k => k.Value == toPId).Key;

            algorithms[mapId].DijkstraAlgo(from);
            List<int> path = algorithms[mapId].GetPathForVertex(to);

            int[] pointsId = new int[path.Count];
            for(int i = 0; i < path.Count; ++i)
            {
                pointsId[i] = allIndexes[mapId][path[i]];
            }

            return pointsId;
        }
        private void CreateGraphs()
        {
            List<Map> maps = _mapRepository.GetItems();
            List<Distance> distances = repository.GetItems();
            List<Point> points = _pointRepository.GetItems();

            List<DistanceViewModel> distanceViewModels = _mapper.Map<List<DistanceViewModel>>(distances);
            List<PointViewModel> pointViewModels = _mapper.Map<List<PointViewModel>>(points);
            List<MapViewModel> mapViewModels = _mapper.Map<List<MapViewModel>>(maps);

            allIndexes = new Dictionary<int, Dictionary<int, int>>();
            graphs = new Dictionary<int, double[,]>();
            algorithms = new Dictionary<int, DijkstrasAlgorithm>();

            foreach (var map in mapViewModels)
            {
                List<PointViewModel> currentPoints = pointViewModels.Where(p => p.MapId == map.Id).ToList();
                if (currentPoints.Count == 0)
                {
                    return;
                }
                List<int> pointsId = currentPoints.Select(p => p.Id).ToList();
                Dictionary<int, int> indexes = new Dictionary<int, int>();

                for(int i = 0; i < pointsId.Count; ++i)
                {
                    indexes.Add(i, pointsId[i]);
                }

                allIndexes.Add(map.Id, indexes);

                int n = currentPoints.Count;

                double[,] graph = new double[n, n];

                foreach (DistanceViewModel distance in distanceViewModels)
                {
                    int i = indexes.FirstOrDefault(k => k.Value == distance.FromPointId).Key;
                    int j = indexes.FirstOrDefault(k => k.Value == distance.ToPointId).Key;

                    graph[i, j] = distance.Weight;
                    graph[j, i] = distance.Weight;
                }

                graphs.Add(map.Id, graph);

                algorithms.Add(map.Id, new DijkstrasAlgorithm(graph));
            }            
        }
    }
}